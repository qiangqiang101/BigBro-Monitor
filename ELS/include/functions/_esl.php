<?php

	function login($username, $password) {
		global $config;
		$username = _hash($username.$config['account']['salt']);
		$password = _hash($password.$config['account']['salt']);
		$userHash = _hash($config['account']['user'].$config['account']['salt']);
		$passHash = _hash($config['account']['pass'].$config['account']['salt']);
		if($username==$userHash&&$password==$passHash) {
			_setcookie("username", $userHash, $config['account']['time']);
			_setcookie("password", $passHash, $config['account']['time']);
			return true;
		}
		return false;
	}
	
	function logout() {
		_deletecookie("username");
		_deletecookie("password");
	}

	function isLoggedIn() {
		global $config;
		$userHash = _hash($config['account']['user'].$config['account']['salt']);
		$passHash = _hash($config['account']['pass'].$config['account']['salt']);
		$userHashCookie = _cookie("username");
		$passHashCookie = _cookie("password");
		if($userHash==$userHashCookie&&$passHash==$passHashCookie) {
			return true;
		}
		return false;
	}
	
	function generateKey() {
		global $config;
		$letters = "0123456789";
		$letters2 = "abcdefghijklmnopqrstuvwxyz1234567890";
		$code = "";
		for($i=0; $i<strlen($config['key']['shema']); $i++) {
			switch($config['key']['shema'][$i]) {
				case "D":
					$code.= $letters[rand(0, strlen($letters)-1)];
					break;
				case "E":
					$code.= $letters2[rand(0, strlen($letters)-1)];
					break;
				default:
					$code.=$config['key']['shema'][$i];
			}
		}
		return strtoupper($code);
	}
	
	function getUsers() {
		global $config;
		$con = mysqli_connect($config['mysql']['host'], $config['mysql']['user'], $config['mysql']['pass'], $config['mysql']['datb']);
		$result = mysqli_query($con, "SELECT * FROM `keys` WHERE NOT hwid='' ORDER BY created DESC");
		echo mysqli_error($con);
		$return = array("id", "key", "hwid", "created", "registered", "expiredate", "product");
		$arr = array();
		
		for($i=0; $i<mysqli_num_rows($result); $i++) {
			foreach($return as $k=>$v) {
				$arr[$i][$v] = mysqli_result($result, $i, $v);
			}
		}
		return $arr;
	}
	
	function getKeys() {
		global $config;
		$con = mysqli_connect($config['mysql']['host'], $config['mysql']['user'], $config['mysql']['pass'], $config['mysql']['datb']);
		$result = mysqli_query($con, "SELECT * FROM `keys` WHERE hwid='' ORDER BY created DESC");
		echo mysqli_error($con);
        
		$return = array("id", "key", "created", "date");
		$arr = array();
		for($i=0; $i<mysqli_num_rows($result); $i++) {
			foreach($return as $k=>$v) {
				$arr[$i][$v] = mysqli_result($result, $i, $v);
			}
		}
		return $arr;
	}
	
	function mysqli_result($res,$row=0,$col=0)
	{ 
		$numrows = mysqli_num_rows($res); 
		if ($numrows && $row <= ($numrows-1) && $row >=0){
			mysqli_data_seek($res,$row);
			$resrow = (is_numeric($col)) ? mysqli_fetch_row($res) : mysqli_fetch_assoc($res);
			if (isset($resrow[$col])){
				return $resrow[$col];
			}
		}	
		return false;
	}

	function addKey() {
		global $config;
		$con = mysqli_connect($config['mysql']['host'], $config['mysql']['user'], $config['mysql']['pass'], $config['mysql']['datb']);
		mysqli_query($con, "INSERT INTO `keys` (`key`, `date`) VALUES ('".generateKey()."', '".$_POST['txtDate']."')");
		
	}
	
	function deleteKey($id) {
		global $config;
		$con = mysqli_connect($config['mysql']['host'], $config['mysql']['user'], $config['mysql']['pass'], $config['mysql']['datb']);
		mysqli_query($con, "DELETE FROM `keys` WHERE id = ".$id);
	}

	function resetKey($id) {
		global $config;
		$con = mysqli_connect($config['mysql']['host'], $config['mysql']['user'], $config['mysql']['pass'], $config['mysql']['datb']);
		mysqli_query($con, "UPDATE `keys` SET hwid = '' WHERE id = ".$id);
	}

	/* API */
	function canUse($hwid, $product) { 
		if(!$hwid) { return false; }
		global $config;
		$con = mysqli_connect($config['mysql']['host'], $config['mysql']['user'], $config['mysql']['pass'], $config['mysql']['datb']);
		$result = mysqli_query($con, "SELECT * FROM `keys` WHERE `hwid` = '".$hwid."' AND product = '".$product."'"); 
		return mysqli_num_rows($result)>0;
	}

    function dateCheck($hwid, $config) {
        $db = new PDO('mysql:host='.$config['mysql']['host'].';dbname='.$config['mysql']['datb'].'', $config['mysql']['user'], $config['mysql']['pass']);  

        $stmt = $db->prepare("SELECT * FROM `keys` where hwid = :hwid");

        $stmt->bindParam(":hwid", $hwid);
        $stmt->execute();
        
        $result = $stmt->fetchAll();
        if($result != null) {
         foreach($result as $row) {
           echo $row['product']. $row['expiredate'].":" .$row['product']."<br />"; 
         }
        } else {
        echo "Database returned null";
        }  
         
    }

    
	function isFree($key) {
		if(!$key) { return false; }
		global $config;
		$con = mysqli_connect($config['mysql']['host'], $config['mysql']['user'], $config['mysql']['pass'], $config['mysql']['datb']);
		$result = mysqli_query($con, "SELECT * FROM `keys` WHERE `key` = '".$key."' AND `hwid` = ''");
		return mysqli_num_rows($result)>0;
	}
	
	function isKey($key) {
		$result = mysqli_query("SELECT * FROM `keys` WHERE `key` = '".$key."'");
		return mysqli_num_rows($result)>0;
	}
	
	function registerKey($key, $hwid, $product, $config) {
		if(!$hwid) { return "error: wrong hwid"; }
		if(!$key) { return "error: wrong key"; }
		if(!isKey($key)) { return "error: wrong key"; }
		if(!isFree($key)) { return "error: key is already in use"; }  
        $db = new PDO('mysql:host='.$config['mysql']['host'].';dbname='.$config['mysql']['datb'].'', $config['mysql']['user'], $config['mysql']['pass']); 
        $stmt = $db->prepare("SELECT * FROM `keys` where `key` = :key");
        $stmt->bindParam(":key", $key);
        $stmt->execute();

        // Result holen
        $result = $stmt->fetchAll();
        if($result != null) {
         foreach($result as $row) {
            $timestamp = strtotime($row['date']. "days"); 
         }
        } else {
        echo "Database returned null";
        }  
		mysqli_query("UPDATE `keys` SET `hwid` = '".$hwid."',  `expiredate` = '".date("Y-m-d", $timestamp)."', `product` = '".$product."', `registered` = '".date("Y-m-d H:i:s", time())."' WHERE `key` = '".$key."'");
		return canUse($hwid);
	}

?>
