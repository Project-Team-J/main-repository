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

    function __construct()
    {
        $this->app = new App();
        $this->app->setg_Client('http://api.wunderground.com/api/c72ab3004b49b23f/');
        $this->data = $this->app->getJsonData('forecast/geolookup/conditions/q/autoip.json');
    }

    function getData()
    {
        return $this->data;
    }
}