<?php
require_once("DB/dbconnect.php");

$query = Database::prepare("SELECT idMatch,idTeam1,idTeam2,team1Score,team2Score,stadium,matchState,startDateTime FROM football.match ORDER BY startDateTime DESC");
$query->execute();
echo json_encode($query->fetchAll(PDO::FETCH_ASSOC));

?>