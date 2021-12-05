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

// total of 'some database table'
function total_of($from)
{
	$query = dbquery('SELECT COUNT(*) FROM '.$from);
	$rows = $query->fetch_row();
	return $rows[0];
}

// load admin usernames
function load_admins($h = "")
{
	$query = dbquery('SELECT uid, username FROM users WHERE rank = 2');
	while($data = $query->fetch_assoc()) { $h .= '<a href="edit_user?uid='.$data["uid"].'">'.$data["username"].'</a>'; }
	return $h;
}

// page params
$tpl->set_param("total_mods", total_of("mods"));
$tpl->set_param("total_users", total_of("users"));
$tpl->set_param("total_comments", total_of("comments"));
$tpl->set_param("admins", load_admins());
$tpl->set_param("notes", str_replace('\r',"\r",str_replace('\n',"\n", file_get_contents(ADM_NOTES))));

// page
$tpl->set_param("sel_cat", 0);
$tpl->set_param("page_title", "Dashboard");
$tpl->load("adm_head");
$tpl->load("adm_dashboard");
$tpl->load("adm_footer");
$tpl->output();
?>