<?php

    try{
        $bdd = new PDO("mysql:host=localhost;dbname=login","root","");
    }catch ( Exception $e){
    die("ERROR ". $e->getMessage());
    }
?>