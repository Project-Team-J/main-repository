<?php

require_once('Database.php');
require_once('widgets/daily_word/DAILYWORD.php');
require_once('widgets/translation/TRANSLATION.php');
require_once('widgets/exchange/EXCHANGE.php');
require_once('widgets/weather/WEATHER.php');
require_once('widgets/todo_list/TODO_LIST.php');
require_once('widgets/music/MUSIC.php');
require_once('widgets/photo_album/PHOTO_ALBUM.php');
class USER
{
    private $conn;
    var $id;
    public function __construct()
    {
        $database = new Database();
        $db = $database->dbConnection();
        $this->conn = $db;
    }
    public function getConn(){
        return $this->conn;
    }

    public function runQuery($sql)
    {
        $stmt = $this->conn->prepare($sql);
        return $stmt;
    }

    public function register($uname,$umail,$upass)
    {
        try
        {
            $new_password = password_hash($upass, PASSWORD_DEFAULT);
            $stmt = $this->conn->prepare("INSERT INTO users(user_name,user_email,user_pass) VALUES(:uname, :umail, :upass)");
            $stmt->bindparam(":uname", $uname);
            $stmt->bindparam(":umail", $umail);
            $stmt->bindparam(":upass", $new_password);
            $stmt->execute();
            return $stmt;
        }
        catch(PDOException $e)
        {
            echo $e->getMessage();
        }
    }


    /**
     * @param $uname
     * @param $umail
     * @param $upass
     * @return bool
     */
    public function doLogin($uname, $umail, $upass)
    {

        try
        {
            $stmt = $this->conn->prepare("SELECT user_id, user_name, user_email, user_pass FROM users WHERE user_name=:uname OR user_email=:umail ");
            $stmt->execute(array(':uname'=>$uname, ':umail'=>$umail));
            $userRow=$stmt->fetch(PDO::FETCH_ASSOC);

            if($stmt->rowCount() == 1)
            {
                if(password_verify($upass, $userRow['user_pass']))
                {
                    $_SESSION['user_session'] = $userRow['user_id'];
                    $this->id = $_SESSION['user_session'];
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        catch(PDOException $e)
        {
            echo $e->getMessage();
        }
    }

    public function is_loggedin()
    {
        if(isset($_SESSION['user_session']))
        {
            return true;
        }
    }

    public function redirect($url)
    {
        header("Location: $url");
    }

    public function doLogout()
    {
        session_destroy();
        unset($_SESSION['user_session']);
        return true;
    }
    public function getId()
    {

            return $this->id;

    }

}
?>