<?php

/**
 * Created by PhpStorm.
 * User: user
 * Date: 07/05/2017
 * Time: 16:02
 */
class TODO_LIST
{
    private $conn;
    private $user;
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
                    $tmp = array('taskid' => $userRow['task_id'], 'Task' => $userRow['task'], 'Date' => $userRow['task_date']);
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
    public function addTask($tasks,$dates)
    {
        $stmt = $this->conn->prepare("INSERT INTO todo_list(task,task_date,user_name) VALUES(:tasks, :dates,'$this->user')");
        $stmt->bindparam(":tasks", $tasks);
        if ($dates != null)
            $stmt->bindparam(":dates", $dates);
        else {
            $d = "1990-01-01";
            $stmt->bindparam(":dates", $d);
        }
        $stmt->execute();
        return $stmt;


    }
    public function deleteTask($taskid)
    {
        $stmt = $this->conn->prepare("DELETE FROM `todo_list` WHERE `todo_list`.`task_id` = :taskid");
        $stmt->bindparam(":taskid", $taskid);
        $stmt->execute();
        return $stmt;
    }

    public function run(){
        if (isset($_POST['get_tasks']))
            $this->getTask();
        if (isset($_POST['add'])) {
            $this->addTask($_POST['task'],$_POST['date']);
        }
        if (isset($_POST['delete'])) {
            $this->deleteTask($_POST['task_id']);
        }
    }
}



