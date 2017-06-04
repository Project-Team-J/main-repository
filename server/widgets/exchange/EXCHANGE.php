<?php

/**
 * Created by PhpStorm.
 * User: Reouven Bentolila
 * Date: 15-Apr-17
 * Time: 7:16 PM
 */
class EXCHANGE
{

    private $app;
    private $data;
    private $from;
    private $to;
    private $amount;


    function __construct($from, $to, $amount)
    {
        $this->app = App::get_instance();
        $this->amount = $amount;


        $this->from = $from;
        $this->to = $to;
        if($to=='empty')
        {
            $this->data=json_encode(array('result' => (string)$amount));
        }
        else if($from=='empty')
        {
            $this->data=json_encode(array('result' => "please enter correct parameters"));
        }
        else if($this->to==$this->from)
        {
            $this->data = json_encode(array('result' => $amount));
        }
        else
        {
            $this->app->setg_Client('https://api.fixer.io/');
            $this->data = $this->app->getJsonData('latest?base='.$this->from.'');
            $this->data = (array)json_decode($this->data);
            $rate = $this->data['rates']->$to;
            $result = $amount*$rate;
            $this->data = json_encode(array('result' => (string)$result));
        }



    }


    public function getamount()
    {
        return $this->amount;
    }


    public function setfrom($from)
    {
        $this->from = $from;
    }
    public function setto($to)
    {
        $this->to = $to;
    }

    public function setText($text)
    {
        $this->text = $text;
    }

    function getData()
    {
        return $this->data;
    }

    function run(){

        echo $this->getData();
    }
}