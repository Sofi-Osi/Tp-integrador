<?php
$to = "info@hotmail.com";
$subject = "Mail desde el formulario";
$headers = "MIME-Version: 1.0" . "\r\n";
$headers .= "Content-type:text/html;charset=UTF-8" . "\r\n";

$nombre = $_POST['nombre'];
$email = $_POST['email'];
$comentarios = $_POST['comentarios'];

$message = "
<html>
<head>
<title>HTML</title>
</head>
<body>
<h1>Información del formulario</h1>
<p><strong>Nombre:</strong> $nombre</p> 
<p><strong>Email:</strong> $email</p> 
<p><strong>Comentarios:</strong> $comentarios</p> 
</body>
</html>";

if (mail($to, $subject, $message, $headers)) {
  echo 'Gracias por comunicarse con nosotros';
} else {
  echo 'Error al enviar el mensaje. Intente más tarde.';
}
?>
