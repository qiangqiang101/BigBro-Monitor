<?php
/*======================================================================
| modsCMS - Build your own game mods website!
| ======================================================================
| This is a paid software, do not redistribute, support the developers.
| See licenses for more information about the use of the software.
\======================================================================*/

// core functions
include_once "core.php";

// check if file id exists
if(isset($_GET["fid"]))
{
	// file path
	$file_url = 'uploads/files/'.$_GET["fid"];
	
	// check if file exists
	if(file_exists($file_url))
	{
		// force file download
		header('Content-Type: application/octet-stream');
		header("Content-Transfer-Encoding: Binary"); 
		header("Content-disposition: attachment; filename=\"" . basename($file_url) . "\""); 
		readfile($file_url);	
	}
	else
	{
		// load 404 file page
		$tpl->load("file_404");
		$tpl->output();
	}
}
else
{
	// error message
	header("Location: ".SITE_URL."404?invalidFileId"); exit;
}

?>