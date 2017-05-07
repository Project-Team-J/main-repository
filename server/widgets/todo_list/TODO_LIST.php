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
    private $id;
    private $data;
    public function __construct($id)
    {
        $database = new Database();
        $db = $database->dbConnection();
        $this->conn = $db;
        $this->id = $id;
    }
    public function getConn(){
        return $this->conn;
    }
    public function runQuery($sql)
    {
        $stmt = $this->conn->prepare($sql);
        return $stmt;
    }
    public function getTask($uid)
    {
        try {
            $stmt = $this->conn->prepare("SELECT task,task_date FROM todo_list WHERE user_id=:uid ");
            $stmt->execute(array(':uid' => $uid));
            $rows = array();
            while ($userRow = $stmt->fetch(PDO::FETCH_ASSOC)) {
                // $userRow['task_date'] = '' . $userRow['task_date'];
                //$rows[] = $userRow;
                echo json_encode($userRow);
            }

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
    public function deleteTask($uid)
    {
        $sql="DELETE FROM todo_list WHERE user_id=:uid";
        return $sql;
    }

    public function run(){
        echo getTask($this->id);
        if (isset($_POST['add'])) {
            $task = trim($_POST['task']);
            $d = trim($_POST['date']);
            // $d=DateTime::ATOM;
            $this->addTask($this->id, $task, $d);
        }
        // if (isset($_POST['delete'])) {
        // }
    }
}



