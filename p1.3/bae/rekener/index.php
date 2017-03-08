<?php
$num1 = $num2 =$num3 =$num4 ="";
$operand = "";
if(isset($_GET['num1']) && isset($_GET['num2'])&& isset($_GET['num3']) && isset($_GET['num4']) && isset($_GET['operand']))
{
    $num1 = $_GET['num1'];
    $num2 = $_GET['num2'];
    $num3 = $_GET['num3'];
    $num4 = $_GET['num4'];
    $operand = $_GET['operand'];
}

function calc($num1,  $num2,  $num3,  $num4, $operand)
{
    switch($operand)
    {
        case "+": return ($num1 + $num2 + $num3 + $num4); break;
        case "-": return ($num1 - $num2 - $num3 - $num4 ); break;
        case "*": return ($num1 * $num2 * $num3 * $num4 ); break;
        case "/": 
			if($num1 == 0 or $num2 == 0 or $num3 or $num4 == 0)
				return "Delen door 0? Dat kan toch niet man. Doe ff normaal.";
		return ($num1 / $num2 / $num3 / $num4 ); break;
        default : return ("geen of verkeerde operand $operand ingevoerd" ); break;
    }
}
function printSource(){
    echo "<h1>Source code</h1><code>";
	show_source("index.php");
	echo "</code>";
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <title>Functies</title>
    <style type="text/css">
        body {
            font-family: "Arial Black", monospace;
            background-color: #ff6699;
            margin: auto;
            text-align: center;
        }

        p {
            color:white;
            font-weight: bold;
        }

        legend{
            color:white;
            font-size: 200%;
			text-align:left;
        }
		
		#cool {
			background-color:#fff;
			border: 2px solid green;
			padding:1em;
			width:900px;
			margin: 0 auto;
			text-align:left;
			color:black;
			
		}

        fieldset{
            width: 320px;
            border: 2px black solid;
            background-color: #660066;
            margin: auto;
			color:white;
			border-radius:1em;
        }
    </style>
</head>
<body>
<div> Antonio Bottelier GD1A</div>
<form action="<?php echo $_SERVER['PHP_SELF']; ?>" method="GET">
    <fieldset>
        <legend>Berekening</legend>
        <p>A: <input type="text" name="num1" placeholder = "getal" value = "<?php echo $num1 ?>"></p>
        <p>B: <input type="text" name="num2" placeholder = "getal" value = "<?php echo $num2 ?>"></p>
        <p>C: <input type="text" name="num3" placeholder = "getal" value = "<?php echo $num3 ?>"></p>
        <p>D: <input type="text" name="num4" placeholder = "getal" value = "<?php echo $num4 ?>"></p>
        <p>Bewerking +-*/: <input type="text" size = "8" placeholder = "bewerking" name="operand" value = "<?php echo $operand ?>"></p>
        <p><input type="submit" name="versturen" value="Versturen"></p>
    </fieldset>
    <p><?php echo "Het resultaat $operand: ". calc($num1,  $num2,  $num3,  $num4, $operand); ?></p>
</form>
<hr>
<div id="cool" ><?php printSource(); ?></div>
</body>
</html>

