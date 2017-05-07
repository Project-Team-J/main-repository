<?php
require 'vendor/autoload.php';
use GuzzleHttp\Client;

class App
{
    public $gClient;
    static protected $_instance = null;
    
    function __construct(){
        $this->gClient = new Client();
    }

    function setg_Client($uri)
    {
        $this->gClient = new Client(['base_uri' => $uri,'timeout'  => 2.0,]);
    }

    function getJsonData($URI)
    {
        $response = $this->gClient->request('GET', $URI);
        $body = $response->getBody();
        return $body->getContents();
    }
    
    public static function instance() {
        if(!static::$_instance) {
            static::$_instance = new App();
        }
        
        return static::$_instance;
    }
}