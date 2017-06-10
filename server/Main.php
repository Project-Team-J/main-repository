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

    function __construct()
    {
    }

    function Run()
    {
        require_once("User.php");
        require_once './App.php';
        $login = new USER();
        $arr = array();
<<<<<<< HEAD
        if (isset($_POST['login'])) {
=======
        if(isset($_POST['login'])) {
>>>>>>> 3fe3341527d33a0f03e44104ee5a279b319009f1
            $uname = strip_tags($_POST['username']);
            $umail = strip_tags($_POST['username']);
            $upass = strip_tags($_POST['password']);
            if ($login->doLogin($uname, $umail, $upass)) {
                $arr['msg'] = "login successfully!";
<<<<<<< HEAD
            } else {
=======
            }
            else {
>>>>>>> 3fe3341527d33a0f03e44104ee5a279b319009f1
                $arr['msg'] = "Wrong Details!";
            }
            echo json_encode($arr);
        }
<<<<<<< HEAD
        if (isset($_POST['register']) && isset($_POST['user_name']) && isset($_POST['user_mail']) && isset($_POST['user_pass'])) {
            $uname = trim($_POST['user_name']);
            $umail = trim($_POST['user_mail']);
            $upass = trim($_POST['user_pass']);
            if (preg_match("/[\W]+/", $uname) || strlen($uname) == 0) {
=======

        if (isset($_POST['register']) && isset($_POST['user_name']) && isset($_POST['user_mail']) && isset($_POST['user_pass']))
        {
            $uname = trim($_POST['user_name']);
            $umail = trim($_POST['user_mail']);
            $upass = trim($_POST['user_pass']);
            if(preg_match("/[\W]+/", $uname) || strlen($uname) == 0) {
>>>>>>> 3fe3341527d33a0f03e44104ee5a279b319009f1
                $this->msg = "invalid username!";
            }
            if (filter_var($umail, FILTER_VALIDATE_EMAIL) === false || strlen($umail) > 60) {
                $this->msg = $this->msg . "invalid email!";
<<<<<<< HEAD
            }
            $stmt = $login->getConn()->prepare("SELECT user_name,user_email FROM users WHERE user_name=:uname OR user_email=:umail");
            $stmt->execute(array(':uname' => $uname, ':umail' => $umail));
            $row = $stmt->fetch(PDO::FETCH_ASSOC);
            if ($row['user_name'] == $uname) {
                $this->msg = $this->msg . "Sorry username already taken!";
            } else if ($row['user_email'] == $umail) {
                $this->msg = $this->msg . "Sorry email id already taken!";
            }
            $arr['msg'] = $this->msg;
            if ($this->msg == "") {
                $login->register($uname, $umail, $upass);
                $arr['msg'] = "register successfully!";
            }
=======
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
            $arr['msg'] = $this->msg;
            if ($this->msg == "") {
                $login->register($uname, $umail, $upass);
                $arr['msg'] = "register successfully!";
            }
>>>>>>> 3fe3341527d33a0f03e44104ee5a279b319009f1
            echo json_encode($arr);
        }
        if (isset($_POST['daily_word'])) {
            $dw = new DAILYWORD();
            $dw->run();
        }
        if (isset($_POST['translation']) && isset($_POST['text']) && isset($_POST['lang'])) {
            $ts = new TRANSLATION($_POST['text'], $_POST['lang']);
            $ts->run();
        }
        if (isset($_POST['exchange']) && isset($_POST['amount']) && isset($_POST['to']) && isset($_POST['from'])) {
            $ex = new EXCHANGE($_POST['from'], $_POST['to'], $_POST['amount']);
            $ex->run();
        }
        if (isset($_POST['weather'])) {
            $we = new WEATHER();
            $we->run();
        }
<<<<<<< HEAD
        if (isset($_POST['music'])) {
            $m = new MUSIC();
=======
        if (isset($_POST['music']))
        {
            $m=new MUSIC();
>>>>>>> 3fe3341527d33a0f03e44104ee5a279b319009f1
            $m->run();
        }
        if (isset($_POST['pa'])) {
            $p = new PHOTO_ALBUM($_POST['word']);
            $p->run();
        }
        if (isset($_POST['todo_list'])) {
            $uname = strip_tags($_POST['uname']);
            $upass = strip_tags($_POST['upass']);
            if ($login->doLogin($uname, $uname, $upass)) {
                $tl = new TODO_LIST($uname);
                $tl->run();
            }
        }
<<<<<<< HEAD
=======
        if (isset($_POST['todo_list_add'])) {
            $uname = strip_tags($_POST['uname']);
            $upass = strip_tags($_POST['upass']);
            $task = trim($_POST['task']);
            if ($login->doLogin($uname, $uname, $upass)) {
                $tl = new TODO_LIST($uname);
                $tl->addTask("or", $task, "2017/08/04");;
            }
        }
        if (isset($_POST['todo_list_delete'])) {
            $uname = strip_tags($_POST['uname']);
            $upass = strip_tags($_POST['upass']);
            $task = trim($_POST['task']);
            $d = trim($_POST['date']);
            if ($login->doLogin($uname, $uname, $upass)) {
                $tl = new TODO_LIST($uname);
                $tl->deleteTask($uname, $task, $d);
            }
        }
>>>>>>> 3fe3341527d33a0f03e44104ee5a279b319009f1
    }
}
?>