
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:http/retry.dart';
import 'package:scan/models/ambientes_model.dart';
import 'package:scan/models/login_model.dart';
import 'package:scan/models/notification_model.dart';

import '../models/checkin_post_model.dart';

class API {
  Future<AmbienteModel> hasAmbiente(String ambienteId, String token) async {
    final client = RetryClient(http.Client());
    late String _json;

    List<AmbienteModel> _ambientesList = [];
    try {
      _json = await client.read(Uri.parse(
          'https://utfpr-scan.herokuapp.com/api/Ambientes/$ambienteId',
          
          ),
          headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
        'Authorization': 'Bearer $token',
        },
      );

      return AmbienteModel.fromMap(await json.decode(_json));
    } catch (e) {
      
      print("erro: $e");
    } finally {
      client.close();
    }
    return AmbienteModel();
  }

  Future<http.Response> login(LoginModel login) {
    return http.post(
      Uri.parse('https://utfpr-scan.herokuapp.com/api/Auth/login-usuario-app'),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
      body: login.toJson(),

    );
  }

  Future<http.Response> notificate(NotificationModel notification, String token) {
    return http.post(
      Uri.parse('https://utfpr-scan.herokuapp.com/api/Notificacoes'),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
        'Authorization': 'Bearer $token',
      },
      body: notification.toJson(),
    );
  }

  Future<http.Response> toCheckIn(CheckinsPostModel ambiente, String token) async {
    print("o token eh $token");
    final response = await http.post(
      Uri.parse('https://utfpr-scan.herokuapp.com/api/Checkins'),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
        'Authorization': 'Bearer $token',
      },
      body: ambiente.toJson(),
    );

    return response;
  }
}
