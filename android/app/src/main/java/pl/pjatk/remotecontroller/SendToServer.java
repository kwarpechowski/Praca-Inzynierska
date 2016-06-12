package pl.pjatk.remotecontroller;

import android.content.Context;
import android.content.SharedPreferences;
import android.preference.PreferenceManager;
import android.util.Log;

import com.github.nkzawa.socketio.client.IO;
import com.github.nkzawa.socketio.client.Socket;

import java.net.URISyntaxException;

/**
 * Created by kamilw on 12.06.2016.
 */
public  class SendToServer {
    private static Socket mSocket = null;

    public static void start(Context context) {
        if(mSocket == null) {
            Log.i("socket", "createServier");

            SharedPreferences SP = PreferenceManager.getDefaultSharedPreferences(context);
            String host = SP.getString("host", "http://172.23.192.127:5555");
            try {
                mSocket = IO.socket(host);
                mSocket.connect();
                mSocket.emit("register_controller");
            } catch (URISyntaxException e) {
            }
        }
    }

    public static void click_button(String buttonName) {
        if(mSocket != null)
        mSocket.emit("click", buttonName);
    }
}
