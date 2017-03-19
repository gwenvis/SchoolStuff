<div style="margin:10% auto;width:300px">

	<h1><?php echo $question; ?></h1>

	<!-- make a post form by adding method="post" -->
	<form name="questionform" method="post">

		<img src="http://www.m8ball.com/answers/en/ball_<?php

		// Bijvoorbeeld: ball_03.gif of ball_21.gif
		// De afbeeldingen zijn geleend van een andere website
		// str_pad zorgt voor een 'voorloopnul' 03 ipv 3
		echo str_pad($ballNumber, 2, "0", STR_PAD_LEFT);

		// Klik op de eightball om het formulier te versturen
		?>.gif" onclick="questionform.submit()"/>

		<div>Question: <textarea name="question" ></textarea></div>

	</form>

</div>