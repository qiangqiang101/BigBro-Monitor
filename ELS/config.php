<?php
	
	// Main
	$config['page']['title'] = "Easy License System";
	$config['page']['version'] = "version 1.0.1";
	
	// MySql
	$config['mysql']['host'] = "localhost";
	$config['mysql']['user'] = "bigbro88_els";
	$config['mysql']['pass'] = "FbU20B0xft";
	$config['mysql']['datb'] = "bigbro88_els";
	
	// Login Data
	$config['account']['user'] = "choisan";
	$config['account']['pass'] = "What is my mother name";
	$config['account']['time'] = 31 * 24 * 60 * 60;
	$config['account']['salt'] = "iamasalt";
	
	// Key
	$config['key']['shema'] = "EDDD-DEDD-DDED-DDDE"; // D = Random NUMBER E = Random Letter
	
	// Other
	$config['users']['perPage'] = 25;
	$config['keys']['perPage'] = 25;
	
	// Pages
	$config['sites_standart'] = "login";
	
	$config['sites']['users'] = array(
		'title' => 'Users',
		'showLoggedIn' => true,
		'showLoggedOut' => false,
		'include' => 'include/pages/users.php'
	);
	
	$config['sites']['keys'] = array(
		'title' => 'Keys',
		'showLoggedIn' => true,
		'showLoggedOut' => false,
		'include' => 'include/pages/keys.php'
	);
	
	$config['sites']['login'] = array(
		'title' => 'Login',
		'showLoggedIn' => false,
		'showLoggedOut' => true,
		'include' => 'include/pages/login.php'
	);
	
	$config['sites']['about'] = array(
		'title' => 'About',
		'showLoggedIn' => true,
		'showLoggedOut' => true,
		'include' => 'include/pages/about.php'
	);
	
?>
