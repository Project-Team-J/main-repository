<?php
/**
 * Created by PhpStorm.
 * User: Nitzan Tamam
 * Date: 13/04/2017
 * Time: 13:08
 */

class WEATHER
{
    private $app;
    private $data;
    private $path;

    function __construct()
    {
        $this->app = new App();
        $this->app->setg_Client('http://api.wunderground.com/api/c72ab3004b49b23f/');
        $this->data = $this->app->getJsonData('forecast/geolookup/conditions/q/autoip.json');
        $this->data = json_decode($this->data,true);
        $this->normalize($this->data);
        
        //$city = $this->data['current_observation']['display_location']['full'];
 
        
        

    }
    private function normalize($data)
    {
        $path = $data['forecast']['simpleforecast']['forecastday'];
        $date = array(substr($path[0]['date']['pretty'],15),substr($path[1]['date']['pretty'],15),substr($path[2]['date']['pretty'],15),substr($path[3]['date']['pretty'],15));
        $tmph = array($path[0]['high']['celsius'],$path[1]['high']['celsius'],$path[2]['high']['celsius'],$path[3]['high']['celsius']);
        $tmpl = array($path[0]['low']['celsius'],$path[1]['low']['celsius'],$path[2]['low']['celsius'],$path[3]['low']['celsius']);
        $imgs = array($path[0]['icon_url'],$path[1]['icon_url'],$path[2]['icon_url'],$path[3]['icon_url']);
        $humid = array($path[0]['avehumidity'],$path[1]['avehumidity'],$path[2]['avehumidity'],$path[3]['avehumidity']);
        $this->data = json_encode(array('date' => $date , 'tmph' => $tmph , 'tmpl' => $tmpl , 'imgs' => $imgs , 'humid' => $humid));
        
    }
    function getData()
    {
        return $this->data;
    }
    
    function run()
    {
        echo $this->getData();
    }
}