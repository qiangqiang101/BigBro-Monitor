<!doctype html>
<html>
<head>
   <title>%site_name% | %page_title%</title>
   <base href="%site_url%">
   
   <meta charset="utf-8">
   <link rel="stylesheet" href="assets/style.css" />

   <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.0/jquery.min.js"></script>
   <script src="assets/scripts.js"></script>

   <link rel="shortcut icon" href="favicon.ico" type="image/x-icon">
   <link rel="icon" href="favicon.ico" type="image/x-icon">
</head>

<body spellcheck="false">

<div class="img-viewer" onClick="close_img();"></div>
<div class="modal-bg"><div class="modal"><div class="m-title cf"></div><div class="m-body"></div></div></div>

<div class="www">
   
   <div class="top">
      <div class="big-loader"></div>
      <div class="marg cf">
         <a href="adm"><div class="logo"><img src="assets/admin_logo.png"></div></a>
         <div class="search"><form action="adm_search" method="GET"><input autocomplete="off" name="term" maxlength="35" type="text" required placeholder="Search"></form></div>
         <div class="menus"><a class="btn" href="%site_url%">Back to website</a></div>
      </div>
   </div>

   <div class="cats">
      <div class="marg">
         <a id="c_0" href="adm">Dashboard</a>
         <a id="c_1" href="adm_mods">Themes</a>
         <a id="c_2" href="adm_users">Users</a>
         <a id="c_3" href="adm_ads">Advertisements</a>
         <a id="c_4" href="adm_settings">Settings</a>
      </div>
   </div>
   
   <div class="cont">