<?php

	function mysqlconnect() {
		global $config;
		$con = mysqli_connect($config['mysql']['host'], $config['mysql']['user'], $config['mysql']['pass'], $config['mysql']['datb']);
		mysqli_select_db($con, $config['mysql']['datb']) or die("MySql: Can not select database.");
	}
	
	function mysqlclose() {
		global $config;
		$con = mysqli_connect($config['mysql']['host'], $config['mysql']['user'], $config['mysql']['pass'], $config['mysql']['datb']);
		mysqli_close($con);
	}

?>