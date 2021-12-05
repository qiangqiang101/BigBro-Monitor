<?php
/*======================================================================
| modsCMS - Build your own game mods website!
| ======================================================================
| This is a paid software, do not redistribute, support the developers.
| See licenses for more information about the use of the software.
\======================================================================*/

// core functions
include_once "core.php";

// session check
seg(3);

// check if mod is is valid
if(isset($_GET["mid"]) && is_numeric($_GET["mid"]))
{
	// mod id
	$mid = filter($_GET["mid"]);
	
	// load mod by id
	$mods->load($mid, "mid"); 
	
	// check if mod exists
	if($mods->exists)
	{
		// page params
		$tpl->set_param("noi", $config["noi"]); // max number of gallery images
		$tpl->set_param("mod_id", $mods->id);
		$tpl->set_param("mod_name", $mods->name);
		$tpl->set_param("mod_status", $mods->status);
		$tpl->set_param("version", $mods->version);
		$tpl->set_param("author", $mods->author);
		$tpl->set_param("cat_id", $mods->category);
		$tpl->set_param("description", $mods->description);
		$tpl->set_param("file_id", $mods->file_id);
		$tpl->set_param("mod_seo", $mods->seo);
		$tpl->set_param("user_id", $mods->user_id);
		$tpl->set_param("reason", $mods->reason);
		$tpl->set_param("downs", $mods->downloads);
		$tpl->set_param("gallery", $mods->edit_gallery(), true);
		$tpl->set_param("mfs_upload", $config["mfs_upload"]);
		$tpl->set_param("mfs_image", $config["mfs_image"]);
	}
	else
	{
		header("Location: ".SITE_URL."404?invalidModId");
	}
}
else
{
	header("Location: ".SITE_URL."404");
}

// page
$tpl->set_param("sel_cat", 1);
$tpl->set_param("page_title", "Edit Mod");
$tpl->load("adm_head");
$tpl->load("adm_edit_mod");
$tpl->load("adm_footer");
$tpl->output();
?>