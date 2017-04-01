<?php
require 'vendor/autoload.php';
use GuzzleHttp\Client;

class App
{
    public $gClient;

    function __construct()
    {
        $this->gClient = new Client(['base_uri' => 'http://localhost/','timeout'  => 2.0,]);
    }

    function getJsonData($URI)
    {
        $response = $this->gClient->request('GET', $URI);
        $body = $response->getBody();
        return $body;
    }
}