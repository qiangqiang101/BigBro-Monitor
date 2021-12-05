<?php
/*======================================================================
| modsCMS - Build your own game mods website!
| ======================================================================
| This is a paid software, do not redistribute, support the developers.
| See licenses for more information about the use of the software.
\======================================================================*/

class database{
	
	// class variables
	public $con;
	public $con_query;
	public $charset = "utf8";
	
	function __construct($host, $username, $password, $name)
	{
		// check if there are empty values in the inc.config.php	
		if(empty($host) || empty($username) || empty($password) || empty($name))
		{
			// redirect to website setup
			self::to_setup();
		}
		else
		{
			// try to connect to mysql database
			$this->con = @mysqli_connect($host, $username, $password, $name);
			
			// check connection
			if($this->con)
			{
				// everything is fine, set default charset (utf8)
				$this->con->set_charset($this->charset);
			}
			else
			{
				// redirect to website setup
				self::to_setup();
			}
		}
	}
	
	// execute a mysqli query
	function q($query)
	{
		$this->con_query = $this->con->query($query);
		return $this->con_query;
	}
	
	// free memory of a mysqli query
	function free_memory()
	{
		mysqli_free_result($this->con_query);
	}
	
	// redirect to website setup
	function to_setup()
	{
		header("Location: setup/index.php"); exit;
	}
	
	// load website configuration
	function website_config()
	{
		$query = $this->q("SELECT * FROM config");
		return mysqli_fetch_assoc($query);
	}
}

?>