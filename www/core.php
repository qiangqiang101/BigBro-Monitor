<?php
/*======================================================================
| modsCMS - Build your own game mods website!
| ======================================================================
| This is a paid software, do not redistribute, support the developers.
| See licenses for more information about the use of the software.
\======================================================================*/

error_reporting(E_ALL);
session_start();

// include classes
include_once "inc/inc.config.php";
include_once "inc/inc.vars.php";
include_once "inc/class.db.php";
include_once "inc/class.template.php";
include_once "inc/class.users.php";
include_once "inc/class.mods.php";

// user session values
if(!empty($_SESSION["uid"]))
{
	// online user
	$sess_id   = $_SESSION["uid"];
	$sess_user = $_SESSION["username"];
	$sess_rank = $_SESSION["rank"];
	$sess_on   = true;
	$sess_avatar = $_SESSION["avatar"];
}
else
{
	// offline user
	$sess_id   = 0;
	$sess_user = null;
	$sess_rank = 0;
	$sess_on   = false;
	$sess_avatar = "";
}

// global values
define("UID",      $sess_id);
define("USERNAME", $sess_user);
define("RANK",     $sess_rank);
define("ONLINE",   $sess_on);
define("AVATAR",   $sess_avatar);

// start database class
$db = new database($db_host, $db_user, $db_pass, $db_name);

// website settings
$config = $db->website_config();

// template & mods classes
$tpl = new template($config);
$mods = new mods($config);

// website url
define("SITE_URL", $config["site_url"]);

// extra functions
include_once "inc/inc.extra.php";

?>