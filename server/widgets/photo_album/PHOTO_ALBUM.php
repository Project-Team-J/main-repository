<?php

/**
 * Created by PhpStorm.
 * User: Tomer Oliel
 * Date: 25/05/2017
 * Time: 18:37
 */
class PHOTO_ALBUM
{
    private $data;

    function __construct($word){
        $app = get_instance();
        $app->setg_Client('https://api.gettyimages.com');
        $response = $app->getGClient()->get('/v3/search/images?phrase='.$word.'', ['headers' => ['Api-Key' => 'j6g7eefn4av9p8yertf72g2e']]);
        $array = $response->getBody()->getContents();
        $json = json_decode($array, true);
        $this->data = json_encode($this->normalize($json));
    }

    function normalize($json)
    {
        $data = array();
        for ($i = 0;$i < 30;++$i)
            $data['image' . $i . ''] = $json['images'][$i]['display_sizes'][0]['uri'];
        return $data;
    }

    function run(){
        echo $this->data;
    }
}


