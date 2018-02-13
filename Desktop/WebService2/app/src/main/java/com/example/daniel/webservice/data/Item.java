package com.example.daniel.webservice.data;


import org.json.JSONObject;

public class Item implements JSONPopulator {
    private Condition condition;

    public Condition getCondition() {
        return condition;
    }

    @Override
    public void populate(JSONObject data) {
        condition = new Condition();
        condition.populate(data.optJSONObject("condition"));
    }

    @Override
    public JSONObject toJSON() {
        return null;
    }
}

