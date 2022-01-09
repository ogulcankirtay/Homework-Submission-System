<?php
$baglanti=mysqli_connect("localhost","root","123456");
mysqli_select_db($baglanti,"web");
if(isset($_POST["username"]) && isset($_POST["username"]))
{
    $username=$_POST("username");
    $pasword=$_POST("pasword");

    $sql="select * from kullanici where username='$username' and psw='$pasword'";
    $sorgu=mysqli_query($baglanti,$sql);

    $dizi=mysqli_fetch_array($sorgu);
    if($dizi!=0){
        header("location:anasayfa.php");
    }else{
      echo "yanlis";
    }
}
else
echo "yanlis";

?>