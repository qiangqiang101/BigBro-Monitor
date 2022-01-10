<?php
/*======================================================================
| modsCMS - Build your own game mods website!
| ======================================================================
| This is a paid software, do not redistribute, support the developers.
| See licenses for more information about the use of the software.
\======================================================================*/

// core functions
include_once "core.php";

// no session check needed

if(isset($_GET["cid"]))
{
	// category id
	$cid = filter($_GET["cid"]);
	
	// pagination id
	if(isset($_GET["pid"]) && is_numeric($_GET["pid"]) && $_GET["pid"] != 0){ $mods->page_id = $_GET["pid"]; } else { $mods->page_id = 1; }
	
	// page settings
	$mods->page_query = 'catid = "'.$cid.'" AND status = 1';
	$mods->pagination_url = strtolower($mods->cats_list[$cid]).'/';
	
	// set page parameters
	$tpl->set_param("cat_mods_list", $mods->load_list(), true);
	$tpl->set_param("pagination", $mods->pagn());
}

// page
$tpl->set_param("sel_cat", $cid);
$tpl->set_param("page_title", $mods->cats_title_list[$cid]);
$tpl->load("head");
$tpl->load("cat");
$tpl->load("footer");
$tpl->output();
?>