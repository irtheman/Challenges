function MakeJsonObject() {
	param([string] $file, [string] $title, [string] $description, [string] $category, [string] $tags)

	$item = New-Object System.Object
	$item | Add-Member -MemberType NoteProperty -Name "file" -Value $file
	$item | Add-Member -MemberType NoteProperty -Name "title" -Value $title
	$item | Add-Member -MemberType NoteProperty -Name "description" -Value $description
	$item | Add-Member -MemberType NoteProperty -Name "category" -Value $category
	$item | Add-Member -MemberType NoteProperty -Name "tags" -Value $tags

	return $item
}

$data = New-Object System.Collections.ArrayList

$data += MakeJsonObject -file "index.html" -title "index html" -description "View Challenge Library Code" -category "html" -tags "html,js"
$data += MakeJsonObject -file "index.js" -title "index javascript" -description "Javascript for Index.html" -category "js" -tags "html,js"
$data += MakeJsonObject -file "data.js" -title "data json as javascript" -description "Challenge Library Code Data" -category "js" -tags "js,json"
$data += MakeJsonObject -file "BuildScript.ps1" -title "build data.js" -description "Challenge Library Code View Build Script" -category "ps" -tags "ps,json"

dir .\ChallengeLibrary -I *.cs -R |
Select-String -Pattern "Title:" -Context 0,4 |
ForEach-Object {
	$path = "." + $_.Path.Substring($_.Path.IndexOf("\ChallengeLibrary"))
	$title = $_.Line.Substring($_.Line.IndexOf(":") + 1).Trim()
	$desc = $_.Context.PostContext[0]
	$desc = $desc.Substring($desc.IndexOf(":") + 1).Trim()
	$cat = $_.Context.PostContext[1]
	$cat = $cat.Substring($cat.IndexOf(":") + 1).Trim()
	$tags = $_.Context.PostContext[2]
	$tags = $tags.Substring($tags.IndexOf(":") + 1).Trim().Replace(" ", "")

	$data += MakeJsonObject -file $path -title $title -description $desc -category $cat -tags $tags
}

$str = $data | ConvertTo-Json -Depth 100
$str = "var data = { `r`n  'files': " + $str + "};";
$str.Replace("}};", "]};").Replace("'files': {", "'files': [") | Out-File ".\data.js"