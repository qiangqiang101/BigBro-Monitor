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

// check if seo url is valid
if(isset($_GET["seo"]))
{
	// seo id
	$seo = filter(strtolower($_GET["seo"]));
	
	// load mod data by seo id
	$mods->load($seo, "seo");
	
	// check if mod exists
	if($mods->exists && $mods->status == 1)
	{
		$edit_btn = "";
		
		// check if is admin (show edit mod in panel)
		if(RANK == 2){ $edit_btn = '<a class="btn edit_btn" href="adm_edit?mid='.$mods->id.'">Edit Mod (Panel)</a>'; }
		// check if current user is owner, if yes, show edit button
		elseif($mods->user_id == UID){ $edit_btn = '<a class="btn edit_btn" href="edit/'.$seo.'">Edit Mod</a>'; }
		
		// show comments area ? ( if user is online, yes! )
		$com_style = (ONLINE)?'block':'none';
		$join_con  = (ONLINE)?'':'<div class="wbox join">Join the conversation! <a href="login">Log In</a> or <a href="signup">register</a> for an account to be able to comment.</div>';
		
		// last edition html
		$last_edited = (empty($mods->last_edited))?'':'<tr><td>Last Edition:</td><td>'.date('F d, Y', strtotime($mods->last_edited)).'</td></tr>';
		
		// view page params
		$tpl->set_param("mod_id", $mods->id);
		$tpl->set_param("name", $mods->name);
		$tpl->set_param("version", $mods->version);
		$tpl->set_param("seo", $mods->seo);
		$tpl->set_param("author", $mods->author);
		$tpl->set_param("auth_user", $mods->username);
		$tpl->set_param("auth_avatar", $mods->user_avatar);
		$tpl->set_param("edit_btn", $edit_btn);
		$tpl->set_param("downs", $mods->downloads);
		$tpl->set_param("num_com", $mods->comments);
		$tpl->set_param("front_image", $mods->front_image);
		$tpl->set_param("gallery", $mods->load_screens(), true);
		$tpl->set_param("description", str_replace("\n", "<br />", $mods->description));
		$tpl->set_param("up_date", date('F d, Y', strtotime($mods->unix)));		
		$tpl->set_param("last_edited", $last_edited);
		$tpl->set_param("com_style", $com_style);
		$tpl->set_param("join_con", $join_con);
		
		// load comments
		$tpl->set_param("comments", $mods->load_comments($mods->id, 0));
		
		// load more comments button
		$lmc = ($mods->comments > $mods->cpl)?'<input type="button" id="lmc_btn" onclick="lm_comments('.$mods->id.', this);" value="Load More Comments">':'';
		$tpl->set_param("lm_comments", $lmc);
	}
	else
	{
		// not found
		header("Location: ".SITE_URL."404?modNotFound"); exit;
	}
}
else
{
	// return to homepage
	header("Location: ".SITE_URL); exit;
}

// page
$tpl->set_param("sel_cat", $mods->category);
$tpl->set_param("page_title", $mods->name);
$tpl->load("head");
$tpl->load("view");
$tpl->load("footer");
$tpl->output();
?>