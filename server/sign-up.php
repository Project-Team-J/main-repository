<?php
session_start();
require_once('class.user.php');
$user = new USER();


$uname = trim($_POST['user_name']);
$umail = trim($_POST['user_mail']);
$upass = trim($_POST['user_pass']);
if(isset ($_POST['user_name'])&& isset($_POST['user_mail'])&& isset($_POST['user_pass']))
	{
        $user->register($uname,$umail,$upass);



	}

?>
