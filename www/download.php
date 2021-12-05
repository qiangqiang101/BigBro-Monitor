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

// check if seo value exists
if(isset($_GET["seo"]))
{
	// filter seo url
	$seo = filter($_GET["seo"]);
	
	// get mod information by seo
	$query = dbquery('SELECT mid, name, file_id FROM mods WHERE seo = "'.$seo.'" AND status = 1');
	
	if($query->num_rows == 1)
	{
		// load mod load mod information		
		$data = $query->fetch_assoc();
		$mod_id = $data["mid"];
		
		// update total number of downloads
		dbquery('UPDATE mods SET downs = (downs + 1) WHERE mid = '.$mod_id);
		
		// advertising box
		$ad_div = ($config["ads_status"])?'<div class="wbox adsbox" style="padding:20px 25px !important;"><h3>Sponsored Link</h3>'.$config["ads_1"].'</div>':'';
				
		// page params
		$tpl->set_param("mod_seo",  $seo);
		$tpl->set_param("mod_name", $data["name"]);
		$tpl->set_param("file_id",  $data["file_id"]);
		$tpl->set_param("ad_div", $ad_div);
	}
	else
	{
		// mod not found / invalid seo
		header("Location: ".SITE_URL."404?seo=".$seo); exit;
	}
}
else
{
	header("Location: ".SITE_URL); exit;
}

// page
$tpl->set_param("sel_cat", -1);
$tpl->set_param("page_title", "Downloading ".$data["name"]);
$tpl->load("head");
$tpl->load("download");
$tpl->load("footer");
$tpl->output();
?>