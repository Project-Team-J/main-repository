<?php
require 'vendor/autoload.php';
use GuzzleHttp\Client;

class App
{
    public $gClient;
    private static $_instance = null;
    
    private function __construct(){
        $this->gClient = new Client();
    }

    function setg_Client($uri)
    {
        $this->gClient = new Client(['base_uri' => $uri,'timeout'  => 10.0,]);
    }

    function getJsonData($URI)
    {
        $response = $this->gClient->request('GET', $URI);
        $body = $response->getBody();
        return $body->getContents();
    }
    
    public static function get_instance() {
        if(!app::$_instance) {
            app::$_instance = new App();
        }
        
        return app::$_instance;
    }
    public function getGClient():Client
    {
        return $this->gClient;
    }
}