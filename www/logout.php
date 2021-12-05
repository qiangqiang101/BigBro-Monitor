<?php
/*======================================================================
| modsCMS - Build your own game mods website!
| ======================================================================
| This is a paid software, do not redistribute, support the developers.
| See licenses for more information about the use of the software.
\======================================================================*/

// core functions
include_once "core.php";

// check if user is online
if(ONLINE)
{	
	// destroy current user session
	session_destroy();
	$_SESSION = array();
}

// redirect to homepage
header("Location: ".SITE_URL."home"); exit;
?>