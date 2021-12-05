<?php
/*======================================================================
| modsCMS - Build your own game mods website!
| ======================================================================
| This is a paid software, do not redistribute, support the developers.
| See licenses for more information about the use of the software.
\======================================================================*/

//////////// DEFAULT SCRIPT VARIABLES ////////////

// UPLOAD LOG VARIABLES
// if true, everytime an user uploads a new file (mod, avatar, screenshots) it updates
// the log file. Files are saved with the format name month-day-year.txt
define("LOG_STATUS", true);
define("LOG_PATH", "uploads/logs/");

// TEMPLATE VARIABLES
define("TPL_PATH", "inc/tpl/"); // where the tpl files are located

// ADMIN NOTES
// the path of administrator notes file, it's shown on admin dashboard page
// if you rename/change the path don't forget to change the file name too
define("ADM_NOTES", "inc/adm_notes.txt");

?>