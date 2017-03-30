<!---->
<!---->
<?php
//require 'vendor/autoload.php';
//use GuzzleHttp\Client;
//$client = new Client([
//    // Base URI is used with relative requests
//    'base_uri' => 'http://httpbin.org/',
//    // You can set any number of default request options.
//    'timeout'  => 2.0,
//]);
//
//$response = $client->request('GET', 'ip');
//$body = $response->getBody();
//echo $response->getStatusCode(), "<br>";
//echo $body->getContents(), "<br>";
//echo "<pre>";
//print_r(get_class_methods($body));
//echo "</pre>";
//echo "<pre>";
//print_r(get_class_methods($response));
//echo "</pre>";
//?>

<?php
require 'vendor/autoload.php';
use GuzzleHttp\Client;
$client = new Client([
    // Base URI is used with relative requests
    'base_uri' => 'http://localhost/projectj/',
    // You can set any number of default request options.
    'timeout'  => 2.0,
]);

$response = $client->request('GET', 'normalization/wordoftheday');
$body = $response->getBody();
echo $response->getStatusCode(), "<br>";
echo $body->getContents(), "<br>";
echo "<pre>";
print_r(get_class_methods($body));
echo "</pre>";
echo "<pre>";
print_r(get_class_methods($response));
echo "</pre>";
?>
