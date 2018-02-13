package com.example.daniel.webservice;

import android.app.ProgressDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.example.daniel.webservice.data.Channel;
import com.example.daniel.webservice.data.Condition;
import com.example.daniel.webservice.data.Units;
import com.example.daniel.webservice.service.WeatherServiceCallback;
import com.example.daniel.webservice.service.YahooWeatherService;

public class MainActivity extends  AppCompatActivity implements WeatherServiceCallback {

    private ImageView weatherIconImageView;
    private TextView temperatureTextView;
    private TextView conditionTextView;
    private TextView locationTextView;

    private YahooWeatherService service;
    private ProgressDialog dialog;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        weatherIconImageView = (ImageView) findViewById(R.id.imageWeather);
        temperatureTextView = (TextView) findViewById(R.id.temperatureText);
        conditionTextView = (TextView) findViewById(R.id.conditionText);
        locationTextView = (TextView) findViewById(R.id.locationText);

        service = new YahooWeatherService(this);
        service.refreshWeather("Lodz, Lodz, Poland");
    }

    @Override
    protected void onStart() {
        super.onStart();
        dialog = new ProgressDialog(this);
        dialog.setMessage(getString(R.string.loading));
        dialog.setCancelable(false);
        dialog.show();
    }

    @Override
    public void serviceSuccess(Channel channel) {
        dialog.hide();
        Condition condition = channel.getItem().getCondition();
        Units units = channel.getUnits();
        int weatherIconImageResource = getResources().getIdentifier("icon_" + condition.getCode(), "drawable", getPackageName());

        weatherIconImageView.setImageResource(weatherIconImageResource);
        temperatureTextView.setText(getString(R.string.temperature_output, condition.getTemperature(), units.getTemperature()));
        conditionTextView.setText(condition.getDescription());
        locationTextView.setText(channel.getLocation());
    }

    @Override
    public void serviceFailure(Exception exception) {
        dialog.hide();
        Toast.makeText(this, exception.getMessage(), Toast.LENGTH_LONG).show();
    }
}
