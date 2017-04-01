<?php

/**
 * Created by PhpStorm.
 * User: Nitzan Tamam
 * Date: 31/03/2017
 * Time: 15:02
 */
class Main
{
    var $msg = "";
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
            $uname = strip_tags($_POST['username']);
            $umail = strip_tags($_POST['username']);
            $upass = strip_tags($_POST['password']);
            if(preg_match("/[\W]+/", $uname) || strlen($uname) == 0) {
                $this->msg = $this->msg . "invalid username!";
            }
            echo $this->msg;
            if ($this->msg=="") {
                if ($login->doLogin($uname, $umail, $upass)) {
                    echo "login successfully!";
                }
                else {
                    echo "Wrong Details!";
                }
            }
            $this->msg = "";
        }
        if(isset($_POST['register'])) {
            $uname = trim($_POST['user_name']);
            $umail = trim($_POST['user_mail']);
            $upass = trim($_POST['user_pass']);
            if (isset ($_POST['user_name']) && isset($_POST['user_mail']) && isset($_POST['user_pass']))
            {
                if(preg_match("/[\W]+/", $uname) || strlen($uname) == 0) {
                    $this->msg = $this->msg . "invalid username!";
                }
                if (filter_var($umail, FILTER_VALIDATE_EMAIL) === false || strlen($umail) > 60) {
                    $this->msg = $this->msg . "invalid email!";
                }
                echo $this->msg;
                if ($this->msg == "") {
                    $login->register($uname, $umail, $upass);
                    echo "register successfully!";
                }
                $this->msg = null;
            }
            else
            {
                echo "register failed!";
            }
        }
    }
}
?>