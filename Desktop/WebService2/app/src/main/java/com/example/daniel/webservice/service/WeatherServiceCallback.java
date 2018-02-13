package com.example.daniel.webservice.service;

import com.example.daniel.webservice.data.Channel;


public interface WeatherServiceCallback {

    void serviceSuccess(Channel channel);
    void serviceFailure(Exception exception);

}
