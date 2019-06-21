<p align="center">
  <img src="https://puu.sh/DIGKM/4276bf1022.png" alt="REvernus Logo" width="500"/>
</p>
<p align="center">
REvernus is a rewrite of the market/industry/everything eve tool written in C# for Windows!
</p>

## What is Evernus?
Evernus is a market/industry/everything eve tool that is no longer being developed or supported. Currently, its functionality is starting to degrade, and some features are virtually unusable or not working all together.

## What does REvernus do?
Hopefully, everything Evernus did but better and with more features. Currently the project is in super early development and does not have as many features as Evernus, however I am hoping to have a public realase by the end of June/early July with support for order viewing/updating and market analysis, so people can start to use it.

## Why are you re-writing Evernus?
I used to use Evernus a lot back when it was being supported and when I was interested in market stuff, and when I tried to use it recently I found it virually unusable. So, I figured I should take the torch and try and maintain it myself, however I am not that expierenced with C++, and I am a CS student wanting to write something that people can use, so I figured why not re-write the whole thing! I also wish to set up some sort of feature bounty system for the project (for isk), so even if I'm long gone, people can still request features and keep REvernus working for as long as EvE is alive and kicking.

## Does using REvernus violate the EVE EULA? Does it interact with my client?
REvernus is not, and never will intend to, violate the EVE EULA. REvernus only interacts with your game in ways deemed OK by CCP, in this case, via the ESI API. REvernus does **not** interact with your client in any other way. REvernus looks at files created by the eve client, and downloads SDE data from Fuzzworks, along with ESI to get everything it needs to function properly. If there is an issue with how the program works or interacts with anything, please do not hesitate to message me or create an issue, and I will work to get it fixed as soon as possible. With all that said, use this program at your own risk.

## How do I run this program?
At the moment there are no public releases avialable, however you can download the project and build it yourself, check the bottom of this readme on how to do that. I plan to have a build out by at least the end of June 2019 or early January. Check back here or on the EvE Forums thread for updates!

## Can I request features?
You sure can! If you wish to request a feature, ***please*** do not be affraid to make a Feature Request over in the Issues tab at the top of this page!

## Notice for those building REvernus
REvernus uses Net Core 3.0, and does not come with Visual Studio 2019 by default (at least until we get offical support) so you will need to download the [most recent .Net Core 3.0 Preview **SDK** ](https://dotnet.microsoft.com/download/dotnet-core/3.0) and install the [Visual Studio 2019 Preview](https://visualstudio.microsoft.com/vs/preview/) in order to build and run this program. Just load the project, hit F5 and you should be good to go. If theres an issue, please post it in the Issues page.
