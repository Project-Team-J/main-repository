<?php
include "conn.php";


$UserMail= ($_GET{'UserMail'});
$UserPassword= ( ($_GET{'UserPassword'}));

$sql= mysqli_query($conn,"SELECT * FORM users WHERE UserMail = '$UserMail' And UserPassword ='$UserPassword';");
$result = mysqli_query($db,$sql);
$row = mysqli_fetch_array($result,MYSQLI_ASSOC);
$active = $row['active'];
$count = mysqli_num_rows($result);

if ($count ==1)
{
    if($count == 1) {
        sess("myusername");
        $_SESSION['login_user'] = $myusername;

        header("location: welcome.php");
    }else {
        $error = "Your Login Name or Password is invalid
}
else
    echo 'Account non register';




?>
