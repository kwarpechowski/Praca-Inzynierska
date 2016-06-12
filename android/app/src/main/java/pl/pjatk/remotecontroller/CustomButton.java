package pl.pjatk.remotecontroller;

import android.content.Context;
import android.content.res.TypedArray;
import android.util.AttributeSet;
import android.view.View;
import android.widget.Button;

import java.util.HashMap;

public class CustomButton extends Button {
    private static HashMap<String, CustomButton> buttons = new HashMap<String, CustomButton>();
    private String name;

    public static void setLayout(int i) {
        for (CustomButton btn : buttons.values()) {
            btn.setBackgroundResource(i);
        }
    }

    public static void disableButton(String button_name) {
        if(buttons.containsKey(button_name))
            buttons.get(button_name).setEnabled(false);
    }

    public static void enableButton(String button_name) {
        if(buttons.containsKey(button_name))
            buttons.get(button_name).setEnabled(true);
    }

    public static void setText(String button_name, String text) {
        if(buttons.containsKey(button_name))
            buttons.get(button_name).setText(text);
    }

    public String getName() {
        return name;
    }

    public CustomButton(Context context) {
        super(context, null);
        setUp();
    }

    public CustomButton(Context context, AttributeSet attrs) {
        super(context, attrs);

        TypedArray attributes = context.getTheme().obtainStyledAttributes(
                attrs,
                R.styleable.CustomButton,
                0, 0);

        name = attributes.getString(R.styleable.CustomButton_name);

        setUp();
    }

    public CustomButton(Context context, AttributeSet attrs, int defStyleAttr) {
        super(context, attrs, defStyleAttr, 0);
        setUp();
    }

    public CustomButton(Context context, AttributeSet attrs, int defStyleAttr, int defStyleRes) {
        super(context, attrs, defStyleAttr, defStyleRes);
        setUp();
    }

    private void setUp() {
        buttons.put(getName(), this);
        setText(getName());

        setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                ServerCommunication.click_button(getName());
            }
        });

    }

}
