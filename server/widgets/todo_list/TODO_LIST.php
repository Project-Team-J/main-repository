<?php

/**
 * Created by PhpStorm.
 * User: user
 * Date: 07/05/2017
 * Time: 16:02
 */
require_once ('C:\projectj\main-repository\server\Database.php');
class TODO_LIST
{
    private $conn;
    private $user;
    private $data;
    public function __construct($uname)
    {
        $database = new Database();
        $db = $database->dbConnection();
        $this->conn = $db;
        $this->user = &$uname;
    }
    public function getConn(){
        return $this->conn;
    }
    public function runQuery($sql)
    {
        $stmt = $this->conn->prepare($sql);
        return $stmt;
    }
    public function getTask()
    {
        try {
            $stmt=$this->conn->prepare("SELECT * FROM todo_list WHERE user_name='$this->user'");
            $stmt->execute(array());
            if ($stmt) {
                $str = "task";
                $index = 1;
                $arr = array();
                while ($userRow = $stmt->fetch(PDO::FETCH_ASSOC)) {
                    $tmp = array('Task' => $userRow['task'], 'Date' => $userRow['task_date']);
                    $f = $str . $index;
                    $arr[$f] = $tmp;
                    ++$index;
                }
                $arr['amount'] = $index-1;
                echo json_encode($arr);
            }
            else
                echo "no tasks!";

        }
        catch(PDOException $e)
        {
            echo $e->getMessage();
        }
    }
    public function addTask($uid,$tasks,$dates)
    {
        $stmt = $this->conn->prepare("INSERT INTO todo_list(user_id,task,task_date) VALUES(:uid, :tasks, :dates)");
        $stmt->bindparam(":uid", $uid);
        $stmt->bindparam(":tasks", $tasks);
        $stmt->bindparam(":dates", $dates);
        $stmt->execute();
        return $stmt;


    }
    public function deleteTask($uid,$tasks)
    {
        $sql="DELETE FROM todo_list WHERE user_id='$uid'";
        return $sql;
    }

    public function run(){

        $this->getTask();
       //if (isset($_GET['add'])) {
         //   $task = trim($_POST['task']);
          //  $d = trim($_POST['date']);
           // $this->addTask(2, "or" , "23/07/2017" );
       // }
       if (isset($_POST['delete'])) {
          $this->deleteTask(2,trim($_POST['task']));
        }
    }
}



