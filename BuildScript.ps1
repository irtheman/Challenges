function MakeJsonObject() {
	param([string] $file, [string] $title, [string] $category, [string] $tags)

	$item = New-Object System.Object
	$item | Add-Member -MemberType NoteProperty -Name "file" -Value $file
	$item | Add-Member -MemberType NoteProperty -Name "title" -Value $title
	$item | Add-Member -MemberType NoteProperty -Name "category" -Value $category
	$item | Add-Member -MemberType NoteProperty -Name "tags" -Value $tags

	return $item
}

$data = New-Object System.Collections.ArrayList

$data += MakeJsonObject -file "index.html" -title "index html" -category "html" -tags "html,js"
$data += MakeJsonObject -file "index.js" -title "index javascript" -category "js" -tags "html,js"
$data += MakeJsonObject -file "data.js" -title "data json as javascript" -category "js" -tags "js,json"
$data += MakeJsonObject -file "BuildScript.ps1" -title "build data.js" -category "ps" -tags "ps,json"

dir .\ChallengeLibrary -I *.cs -R |
Select-String -Pattern "Title:" -Context 0,3 |
ForEach-Object {
	$path = "." + $_.Path.Substring($_.Path.IndexOf("\ChallengeLibrary"))
	$title = $_.Line.Substring($_.Line.IndexOf(":") + 1).Trim()
	$cat = $_.Context.PostContext[0]
	$cat = $cat.Substring($cat.IndexOf(":") + 1).Trim()
	$tags = $_.Context.PostContext[1]
	$tags = $tags.Substring($tags.IndexOf(":") + 1).Trim().Replace(" ", "")

	$data += MakeJsonObject -file $path -title $title -category $cat -tags $tags
}

$str = $data | ConvertTo-Json -Depth 100
$str = "var data = { `r`n  'files': " + $str.Replace("\\", "\") + "};";
$str.Replace("}};", "]};").Replace("'files': {", "'files': [") | Out-File ".\data.js"