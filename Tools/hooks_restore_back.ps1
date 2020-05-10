$WorkingDirectory="$PSScriptRoot\working-directory"
$ResharperCTLDirectory="$WorkingDirectory\resharper-clt"
$GitHooksDirectory="..\.git\hooks"
$BackendGitHooksDirectory=".\Back GitHooks"
$CommonGitHooksDirectory=".\GitHooks"

New-Item -ItemType Directory -Force -Path $WorkingDirectory

# Install ReSharper CLT

# If there is a folder, where should be ReSharper CTL, means that already installed.
# If there will be a folder, but Resharper CTL is absent - there will be an error.
if (!(Test-Path -Path $ResharperCTLDirectory))
{
	New-Item -ItemType Directory -Force -Path $ResharperCTLDirectory
	New-Item -ItemType Directory -Force -Path "$WorkingDirectory\inspector-reports"
	$ResharperCTLZip="$ResharperCTLDirectory\resharper clt.zip"
	
	# Скачивание Resharper CLT
	Invoke-WebRequest https://data.services.jetbrains.com/products/download?code=RSCLT"&"platform=windows"&"_ga=2.60953260.1435206659.1589097159-948853366.1585888765 -OutFile $ResharperCTLZip
	
	# Распаковка Resharper CLT
	Add-Type -AssemblyName System.IO.Compression.FileSystem
	function Unzip
	{
		param([string]$zipfile, [string]$outpath)

		[System.IO.Compression.ZipFile]::ExtractToDirectory($zipfile, $outpath)
	}

	echo 'Unzip R#'
	Unzip $ResharperCTLZip $ResharperCTLDirectory
}

If (Test-Path $GitHooksDirectory) 
{
	Remove-Item "$GitHooksDirectory\*" -Recurse
}

echo "copy delegating hooks"
Copy-Item $CommonGitHooksDirectory"\*" -Destination $GitHooksDirectory -Force

echo "copy back hooks"
$GitHooks = Copy-Item $BackendGitHooksDirectory"\*" -Destination $GitHooksDirectory -Force -PassThru -Recurse

# Configure back hooks
echo "configure back hooks"
$ProjectFullPath=(get-item $PSScriptRoot).parent.FullName
$Utf8NoBomEncoding = New-Object System.Text.UTF8Encoding $False;
foreach($hook in $GitHooks)
{
	If ($hook.Mode.StartsWith("d")) {continue;}
	
	$Content = [IO.File]::ReadAllText($hook, $Utf8NoBomEncoding)
	
	$Content=$Content.replace('[project-path]', $ProjectFullPath)
	
	[IO.File]::WriteAllLines($hook, $Content, $Utf8NoBomEncoding)
}

echo 'Success'
Read-Host -Prompt "Press Enter to exit"