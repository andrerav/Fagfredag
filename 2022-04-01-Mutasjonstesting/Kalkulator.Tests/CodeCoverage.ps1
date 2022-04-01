# Automates the running of Unit Tests and Code Coverage
# Source: https://stackoverflow.com/a/70321555/495455

# This only needs to be installed once (globally), if installed it fails silently: 
#dotnet tool install -g dotnet-reportgenerator-globaltool

# Save currect directory into a variable
$dir = pwd

if (Test-Path $dir/TestResults/) {
	# Delete previous test run results (there's a bunch of subfolders named with guids)
	Remove-Item -Recurse -Force $dir/TestResults/
}

# Run the Coverlet.Collector (this is an NuGet included with XUnit Test Projects)
$output = [string] (& dotnet test --collect:"XPlat Code Coverage" 2>&1)
Write-Host "Last Exit Code: $lastexitcode"
Write-Host $output

# Extract the GUID from the Output eg, 
#"Attachments:   E:\Dev\XYZ\src\XYZTestProject\TestResults\0f26f16d-bbe8-463b-856b-6d4fbee673bd\coverage.cobertura.xml Passed!"  

$i = $output.LastIndexOf("TestResults") + 11
$j = $output.LastIndexOf("coverage")
$cmdGuid = $output.SubString($i,$j - $i - 1)
Write-Host $cmdGuid 

if (Test-Path $dir/coveragereport/) {
	# Delete previous test run reports - note if you're getting wrong results do a Solution Clean and Rebuild to remove stale DLLs in the bin folder
	Remove-Item -Recurse -Force $dir/coveragereport/
}

# To keep a history of the Code Coverage we need to use the argument:
# -historydir:SOME_DIRECTORY 
if (!(Test-Path -path $dir/CoverageHistory)) {  
 New-Item -ItemType directory -Path $dir/CoverageHistory
}

# Generate the Code Coverage HTML Report
dotnet reportgenerator -reports:"$dir/TestResults/$cmdGuid/coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html -historydir:$dir/CoverageHistory 

# Open the Code Coverage HTML Report (if running on a WorkStation)
$osInfo = Get-CimInstance -ClassName Win32_OperatingSystem
if ($osInfo.ProductType -eq 1) {
(& "$dir/coveragereport/index.html")
}