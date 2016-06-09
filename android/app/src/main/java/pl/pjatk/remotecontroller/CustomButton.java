package pl.pjatk.remotecontroller;

import android.content.Context;
import android.content.res.TypedArray;
import android.util.AttributeSet;
import android.view.View;
import android.view.ViewGroup.LayoutParams;
import android.widget.Button;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by kamilw on 09.06.2016.
 */
public class CustomButton extends Button {
    private static ArrayList<CustomButton> buttons = new ArrayList<CustomButton>();
    private TypedArray attributes;

    public static void setLayout(int i) {

        for (CustomButton btn : buttons) {
            System.out.println("x");
            btn.setBackgroundResource(i);
        }
    }

    private  String getName() {
        return attributes.getString(R.styleable.CustomButton_name);
    }

    private void setUp() {
        setLayoutParams(new LayoutParams(LayoutParams.MATCH_PARENT, LayoutParams.WRAP_CONTENT));
        buttons.add(this);
        setText(getName());

        setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                Toast.makeText(getContext(), "Hello " + getName(), Toast.LENGTH_SHORT).show();
            }
        });
    }


    public CustomButton(Context context) {
        super(context, null);
        setUp();
    }

    public CustomButton(Context context, AttributeSet attrs) {
        super(context, attrs);

        attributes = context.getTheme().obtainStyledAttributes(
                attrs,
                R.styleable.CustomButton,
                0, 0);

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

}
