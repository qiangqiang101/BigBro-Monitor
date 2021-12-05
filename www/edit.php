<?php
/*======================================================================
| modsCMS - Build your own game mods website!
| ======================================================================
| This is a paid software, do not redistribute, support the developers.
| See licenses for more information about the use of the software.
\======================================================================*/

// core functions
include_once "core.php";

seg(2);

if(isset($_GET["seo"]))
{
	// seo id
	$seo = filter(strtolower($_GET["seo"]));
	
	// load mod data by seo
	$mods->load($seo, "seo");
	
	// check if mod exists/is valid
	if($mods->exists && $mods->user_id == UID && $mods->status == 1 || $mods->status == 2)
	{
		$tpl->set_param("noi", $config["noi"]); // max number of gallery images
		$tpl->set_param("mod_id", $mods->id);
		$tpl->set_param("mod_name", $mods->name);
		$tpl->set_param("version", $mods->version);
		$tpl->set_param("author", $mods->author);
		$tpl->set_param("cat_id", $mods->category);
		$tpl->set_param("description", $mods->description);
		$tpl->set_param("file_id", $mods->file_id);
		$tpl->set_param("mod_seo", $seo);
		$tpl->set_param("gallery", $mods->edit_gallery(), true);
		
		// check if mod is rejected/need edition
		if($mods->status == 2 || $mods->status == 3)
		{
			$rej_div = '<div class="rej_div"><h3>Mod Rejection Details</h3><div id="mreason">'. $mods->reason .'</div>Fix the issues now and send us again!</div>';
			$ebtn_id = 3;
		}
		else
		{
			$rej_div = '';
			$ebtn_id = 1;
		}
		
		// more params
		$tpl->set_param("reject_div", $rej_div);
		$tpl->set_param("ebtn_id", $ebtn_id);
		$tpl->set_param("mfs_upload", $config["mfs_upload"]);
		$tpl->set_param("mfs_image", $config["mfs_image"]);
		
	}
	else
	{
		header("Location: ".SITE_URL."404?modNotFound");
	}
}
else
{
	header("Location: ".SITE_URL."404?invalidSEO");
}

// page
$tpl->set_param("sel_cat", -1);
$tpl->set_param("page_title", "Editing Mod");
$tpl->load("head");
$tpl->load("edit");
$tpl->load("footer");
$tpl->output();
?>