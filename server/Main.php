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
    private $app;
    function __construct(){
    }

    function Run()
    {
        session_start();
        require_once("User.php");
        require_once './App.php';
        $login = new USER();
        global $_SESSION;
        if(isset($_POST['login'])) {
            $uname = strip_tags($_POST['username']);
            $umail = strip_tags($_POST['username']);
            $upass = strip_tags($_POST['password']);
            $_SESSION["uname"]=$uname;
            if ($login->doLogin($uname, $umail, $upass)) {
                echo "login successfully!";
            }
            else {
                echo "Wrong Details!";
            }
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
                $stmt = $login->getConn()->prepare("SELECT user_name,user_email FROM users WHERE user_name=:uname OR user_email=:umail");
                $stmt->execute(array(':uname'=>$uname, ':umail'=>$umail));
                $row=$stmt->fetch(PDO::FETCH_ASSOC);
                if($row['user_name']==$uname) {
                    $this->msg = $this->msg . "Sorry username already taken!";
                }
                else if($row['user_email']==$umail) {
                    $this->msg = $this->msg . "Sorry email id already taken!";
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
       if(isset($_POST['daily_word'])) {
            $dw = new DAILYWORD();
            $dw->run();
        }
        if(isset($_POST['translation']) && isset($_POST['text']) && isset($_POST['lang'])) {
            $ts = new TRANSLATION($_POST['text'], $_POST['lang']);
            $ts->run();
        }
        if(isset($_POST['exchange']) && isset($_POST['amount']) && isset($_POST['to']) && isset($_POST['from'])) {
            $ex = new EXCHANGE($_POST['from'], $_POST['to'], $_POST['amount']);
            $ex->run();
        }
        if(isset($_POST['weather'])) {
            $we = new WEATHER();
            $we->run();
        }
        if (isset($_POST['todo_list'])) {

           $tl = new TODO_LIST("or3");
           $tl->run();


        }
        if (isset($_GET['td'])){
            echo $login->getId();
            $tl = new TODO_LIST("or");
            $tl->run();
        }
        if (isset($_POST['music']))
        {
            $m=new MUSIC();
            $m->run();
        }
        if (isset($_POST['pa'])) {
            $p = new PHOTO_ALBUM($_POST['word']);
            $p->run();
        }

    }
}
?>