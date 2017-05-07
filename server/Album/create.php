<html>
<head>
<title> My Album </title>
<link rel='stylesheet' href='style.css' />
</head>
<body>
<?php include 'connect.php'; ?>
<div id='body'>

		<?php include 'title_bar.php'; ?>
		<div id='container'>
			
			<h3>Create Album</h3>
			
			<form method='post'>
			<?php
				
				if(isset($_POST['name'])){
					
					$name = $_POST['name'];
					
					if(empty($name)){
						echo "Please Enter the album Name <br/><br/>";
					} else {
						
						$con = mysqli_query(mysqli_connect('localhost', 'root', '','test'),"INSERT INTO albums (id, name) VALUES ('', $name)");
						if ($con){
							echo 'yes';
						}
						echo "Album Created Succsesfully ! <br/><br/>";
					}
					
				}
			?>
				Album Name : <input type='text' name='name' /> <input type='submit' value='Create' />
			</form>
		</div>
</div>
</body>
</html>