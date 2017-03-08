<!DOCTYPE html>
<html lang="nl">
	 <head>
		<meta charset="utf-8">
		<meta name="description" content="scripting GD">
		<meta name="author" content="Ma">
		<meta name="viewport" content="width=device-width, initial-scale=1.0">
		<link href="https://fonts.googleapis.com/css?family=Source+Code+Pro" rel="stylesheet">
		<link rel="stylesheet" type="text/css" href="style.css">
		<title>PHP String handler</title>
	</head>
	 <body>
		 <?php
		 if ( !empty($_GET)) {
				 $input1 =  $_GET['input1']; // input uit html
				 $input2 =  $_GET['input2']; // input uit html
			 }
			else{
				 $input1 = ""; //lege string
				 $input2 = ""; //lege string
			 }

			 function validEmail($string) {
                 return filter_var($string, FILTER_VALIDATE_EMAIL);
             }

             function getCharPosition($string, $eval) {

             }
		  ?>
		<div class="wrapper">
			<form method="GET" action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]);?>">
				<fieldset>
				 <legend>Antonio Bottelier GD1A</legend>
				 <input type = "text" name = "input1"  value="<?= $input1 ?>"placeholder = "string 1"><br>
				 <input type = "text" name = "input2" value="<?= $input2 ?>"   placeholder = " string 2">
				 <input type = "submit"  id = "submit" name = "submit" value = "submit">
			 </fieldset>
			</form>
			<hr>
			<?php

			?><ul>
				<li>Ingevoerde string 1:  <?= $input1  ?> </li>
				<li>Ingevoerde string 2:  <?= $input2  ?> </li>
				<li>String 1 getrimd trim():  <?= trim($input1)     ?> </li>
                <li>String 1 is een geldig email: <?= validEmail($input1) ? "Ja" : "Nee" ?></li>
                <li>String 2 is een geldig email: <?= validEmail($input2) ? "Ja" : "Nee" ?></li>
                <li>String 3 is de concatenation van string 1 en string 2: <?php $input3 = $input1 . $input2; echo $input3?></li>
                <li>De lengte van string 3 is: <?= strlen($input3) ?></li>
                <li>Zoeken naar spaties. Er zit een spatie op positie :  <?=   strripos($input3," ");    ?> </li>
                <li>Zoeken naar @. Er zit een @ op positie :  <?=   strripos($input3,"@");    ?> </li>
                <li>Zoeken naar "." . Er zit een "." op positie :  <?=   strripos($input3,".");    ?> </li>
                <li>Zoek naar woord "html" vervang dit door "PHP" :  <?=   str_replace("html","PHP",$input3);    ?> </li>
                <li>Wijzig de eerste letter van string 3 naar hoofdletter :  <?=   ucfirst($input3);   ?></li>
                <li>Alles in hoofdletters :  <?=   strtoupper($input3);   ?></li>
				</ul>
				</body>
</html>
