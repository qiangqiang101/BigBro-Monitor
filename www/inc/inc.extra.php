<?php
/*======================================================================
| modsCMS - Build your own game mods website!
| ======================================================================
| This is a paid software, do not redistribute, support the developers.
| See licenses for more information about the use of the software.
\======================================================================*/

// execute a mysql query and return the query result
function dbquery($q)
{
	global $db; return $db->q($q);
}

// filter an input string
function filter($txt)
{
	// check if input is a number
	if(is_numeric($txt))
	{
		return $txt;
	}
	else
	{
		// remove html tags/clean text input/escape strings
		global $db;
		$txt = trim($txt);
		$txt = stripslashes($txt);
		$txt = strip_tags($txt);
		return $db->con->real_escape_string($txt);
	}
}

// check session security
function seg($level)
{
	switch($level)
	{
		// user must be offline
		case 1: if(ONLINE){    header("Location: ".SITE_URL."home");  exit; } break;
		
		// user must be online
		case 2: if(!ONLINE){   header("Location: ".SITE_URL."login"); exit; } break;
		
		// user must be administrator
		case 3: if(RANK != 2){ header("Location: ".SITE_URL."login"); exit; } break;
	}
}

?>