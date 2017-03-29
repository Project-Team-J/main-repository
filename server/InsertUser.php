<?php
    include "conn.php";

    if (isset($_POST['UserName'])&& isset($_POST['UserPassword'])&& isset($_POST['UserMail'])&& isset($_POST['UserImage'])){

        $req=$bdd->prepare("INSERT INTO user(UserName,UserMail,UserPassword,UserImage) VALUES (:UserName,:UserMail,:UserPassword,:UserImage)");
        $req->execute(array(
            'UserName'=>$_POST['UserName'],
            'UserMail'=>$_POST['UserMail'],
            'UserPassword'=>sha1($_POST['UserPassword']),
            'UserImage'=>$_POST['UserImage']
            ));
    }
   move_uploaded_file($_FILES['file']['tmp_name'],"userImage/".$_FILES['file']['name']);

?>