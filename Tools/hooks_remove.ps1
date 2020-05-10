$GitHooksDirectory="..\.git\hooks"

If (Test-Path $GitHooksDirectory) 
{
	Remove-Item "$GitHooksDirectory\*" -Recurse
}

echo 'Success'
Read-Host -Prompt "Press Enter to exit"