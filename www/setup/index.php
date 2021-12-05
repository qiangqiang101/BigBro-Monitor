<?php
/*======================================================================
| modsCMS - Build your own game mods website!
| ======================================================================
| This is a paid software, do not redistribute, support the developers.
| See licenses for more information about the use of the software.
\======================================================================*/

// check if installation step is valid
if(isset($_GET["step"]) && is_numeric($_GET["step"]) && $_GET["step"] != 0){ $step = $_GET["step"]; } else { $step = 1; }
if($step > 5 || $step < 1){ $step = 1; }

// get current website url/domain
function url(){ return sprintf("%s://%s%s",isset($_SERVER['HTTPS']) && $_SERVER['HTTPS'] != 'off' ? 'https' : 'http', $_SERVER['SERVER_NAME'], $_SERVER['REQUEST_URI']); }
?>
<html>
<head>
   <title>modsCMS | Setup</title>
   <meta charset="utf-8" />
   <link rel="stylesheet" href="setup_style.css" />
   <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.0/jquery.min.js"></script>
   <script src="setup_scripts.js"></script>
   <link rel="shortcut icon" href="../favicon.ico" type="image/x-icon">
   <link rel="icon" href="../favicon.ico" type="image/x-icon">
</head>
<body spellcheck="false">
<div class="marg">
   <div class="wbox">
      <div class="top"><img src="setup_logo.png"></div>
<?php if($step == 1){ ?>
   <h2>Welcome</h2>
   Hello, thanks for purchasing modsCMS script.<br>
   We are honored to serve you the best game mods content management system.<br>
   Let's start, we are ready to install! If you have problems, please, contact us.<br><br>
   In the next steps we are going to:
   <ul>
      <li>Connect to MySQL database <small>(Remember to create a new empty database)</small></li>
      <li>Configure website settings</li>
      <li>Create an administrator account</li>
   </ul><br>
   <a class="btn blue" href="index.php?step=2">Start &raquo;</a>
<?php } elseif($step == 2) { ?>
   <h2>1 - Connect to MySQL Database</h2>
   <div class="msg"></div>
   Before you fill the database details, first, you must create an empty database.<br>After the database creation, you can enter the database connection details. If you don't know, contact your host.
   <form>
      <table>
      <tbody>
         <tr><td>Database Host:</td><td><input type="text" name="host" autocomplete="off" placeholder="localhost"></td></tr>
         <tr><td>Username:</td><td><input type="text" name="username" autocomplete="off"></td></tr>
         <tr><td>Password:</td><td><input type="password" name="pass" autocomplete="off"></td></tr>
         <tr><td>Database Name:</td><td><input type="text" name="name" autocomplete="off"></td></tr>
      </tbody>
      </table>
      <input type="button" value="Continue &raquo;" onClick="cmd(2, this.form);"> <img id="loading" src="loading.gif">
      <br><br><small>After click in <b>Continue</b> button, the process may take a minute, be patient.</small>
   </form>
<?php } elseif($step == 3) { ?>
   <h2>2 - Website Settings</h2>
   <div class="msg"></div>
   MySQL database successfully connected! Now we are going to set website details.<br>
   You can change some details later using the administration panel.
   <form>
      <table>
      <tbody>
         <tr><td>Website Name:</td><td><input type="text" name="name" autocomplete="off" placeholder="My Website"></td></tr>
         <tr><td>Website URL:</td><td><input value="<?php echo str_replace("setup/index.php?step=3", "", url()); ?>" type="text" name="url" autocomplete="off" placeholder="http://mysite.com/"><br><small>With the ending slash (/).</small></td></tr>
         <tr><td>Description</td><td><textarea style="width:300px; height:60px;" name="desc"></textarea><br><small>Just a simple description about the site.</small></td></tr>
         <tr><td>Keywords:</td><td><input maxlength="199" type="text" name="keywords" autocomplete="off" placeholder="eg. mods, games, upload, pc"></td></tr>
      </tbody>
      </table>
      <input type="button" value="Continue &raquo;" onClick="cmd(3, this.form);"> <img id="loading" src="loading.gif">
   </form>
<?php } elseif($step == 4) { ?>
   <h2>3 - Administrator Account</h2>
   <div class="msg"></div>
   We're almost done, now we need to create the administrator account.<br>
   You will be able to change some details later.
   <form>
      <table>
      <tbody>
         <tr><td>Username:</td><td><input type="text" name="username" maxlength="15" autocomplete="off"></td></tr>
         <tr><td>Email:</td><td><input type="text" name="email" autocomplete="off"></td></tr>
         <tr><td>Password:</td><td><input type="password" name="pass1" autocomplete="off"></td></tr>
         <tr><td>Confirm Password:</td><td><input type="password" name="pass2" autocomplete="off"></td></tr>
      </tbody>
      </table>
      <input type="button" value="Continue &raquo;" onClick="cmd(4, this.form);"> <img id="loading" src="loading.gif">
   </form>
<?php } elseif($step == 5) { ?>
   <h2>Congratulations!</h2>
   You have successfully installed modsCMS script, your game mods website is now ready to use! If you need support, or if you find bugs, please, contact us.
   <div class="warn">For security reasons rename the setup folder. This will avoid bad intentioned people to re-install the script without your permission.</div>
   <center><a class="btn blue" onClick="redir('../');">Go to Website</a></center>
<?php } ?>
   </div>
   <div class="footer">
      2017 &copy; <a href="http://modscms.com" target="_blank">modsCMS</a><br>
      Installing problems ? Read the documentation or <a href="http://modscms.com" target="_blank">contact us</a>.
   </div>
</div>
</body>
</html>