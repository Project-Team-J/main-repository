<?php

/**
 * Created by PhpStorm.
 * User: Nitzan Tamam
 * Date: 31/03/2017
 * Time: 15:02
 */
class Main
{
    function __construct(){
    }

    function Run()
    {
        session_start();
        require_once("User.php");
        require_once("App.php");
        $app = new App();
        $login = new USER();
//        if($login->is_loggedin()!="")
//        {
//            $login->redirect('home.php');
//        }
        if(isset($_POST['login']))
        {
            $uname = strip_tags($_POST['txt_uname_email']);
            $umail = strip_tags($_POST['txt_uname_email']);
            $upass = strip_tags($_POST['txt_password']);
            if($login->doLogin($uname,$umail,$upass))
            {
//                $login->redirect('home.php');

            }
            else
            {
                $error = "Wrong Details !";
            }
        }
        if(isset($_POST['register'])) {
            $uname = trim($_POST['user_name']);
            $umail = trim($_POST['user_mail']);
            $upass = trim($_POST['user_pass']);
            if (isset ($_POST['user_name']) && isset($_POST['user_mail']) && isset($_POST['user_pass']))
            {
                $login->register($uname, $umail, $upass);
            }
        }
    }
}
?>